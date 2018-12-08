import React from "react";
import { Requests } from "./requests";

export default class App extends React.Component {
    constructor() {
        super();
        const initialState = {
            requests: []
        }
        this.errorHandler = this.errorHandler.bind(this);
        this.investorAmountHandler = this.investorAmountHandler.bind(this);
        this.investorAmountClickAddHandler = this.investorAmountClickAddHandler.bind(this);
        this.investorAmountClickRemoveHandler = this.investorAmountClickRemoveHandler.bind(this);

        this.state = initialState;
    }

    investorAmountClickRemoveHandler(id, e) {
        e.preventDefault();
        const currentElem = this.getRequestById(id);
        const that = this;
        bootbox.dialog({
            title: 'Confirm',
            message: "Are you sure you want to remove your bid?",
            buttons: {
                no: {
                    label: "No",
                    className: "btn-default",
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Remove",
                    className: "btn-danger",
                    callback: function () {
                        $.ajax({
                            method: "DELETE",
                            cache: false,
                            async: true,
                            url: "api/bids/DeleteBidByLoanRequestId/" + currentElem.id,
                            success: (data) => {
                                const updatedElem = that.getRequestById(currentElem.id);
                                updatedElem.doesCurrentInvestorAmountExist = false;
                                updatedElem.currentInvestorAmount = "";
                                const updatedRequests = Object.assign(that.state.requests, { requests: updatedElem });
                                that.setState({ requests: updatedRequests });
                            },
                            error: (xhr, ajaxOptions, thrownError) => {
                                that.errorHandler(xhr, ajaxOptions, thrownError);
                            }
                        });
                    }
                }
            }
        });

    }

    investorAmountClickAddHandler(id, event) {
        event.preventDefault();
        const currentElem = this.getRequestById(id);
        const data = JSON.stringify({
            loanRequestId: currentElem.id,
            currentInvestorAmount: currentElem.currentInvestorAmount
        });
        const that = this;

        bootbox.dialog({
            title: 'Confirm',
            message: "Are you sure you want to add your bid?",
            buttons: {
                no: {
                    label: "No",
                    className: "btn-default",
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Add",
                    className: "btn-warning",
                    callback: function () {
                        $.ajax({
                            method: "POST",
                            data: data,
                            async: true,
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            url: "api/bids/PostBid",
                            success: (data) => {
                                const updatedElem = that.getRequestById(currentElem.id);
                                updatedElem.doesCurrentInvestorAmountExist = true;
                                const updatedRequests = Object.assign(that.state.requests, { requests: updatedElem });
                                that.setState({ requests: updatedRequests });
                            },
                            error: (xhr, ajaxOptions, thrownError) => {
                                that.errorHandler(xhr, ajaxOptions, thrownError);
                            }
                        });
                    }
                }
            }
        });


    }

    errorHandler(x, status, error) {
        bootbox.alert("An unexpected error occurred: " + error +
            ". Please validate your input and try again");
    }

    getRequestById(id) {
        return this.state.requests.filter((item) => {
            if (item.id === id) return item;
        })[0];
    }

    investorAmountHandler(id, event) {

        const currentElem = this.getRequestById(id);

        currentElem.currentInvestorAmount = event.target.value;

        this.setState({ requests: this.state.requests });
    }

    componentDidMount() {
        const that = this;

        $.ajax({
            method: "GET",
            cache: false,
            async: true,
            url: "api/LoanRequests",
            success: (data) => {
                if (data && data.length > 0) {

                    const requests = data.map((i => {
                        if (i.currentInvestorAmount) {
                            i.doesCurrentInvestorAmountExist = true;
                        }
                    }));

                    that.setState({ requests: data })
                }

            },
            error: (xhr, ajaxOptions, thrownError) => {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    }

    render() {
        return (
            <div><Requests
                requests={this.state.requests}
                investorAmountHandler={this.investorAmountHandler}
                investorAmountClickAddHandler={this.investorAmountClickAddHandler}
                investorAmountClickRemoveHandler={this.investorAmountClickRemoveHandler} /></div>
        )
    }

}
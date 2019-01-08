﻿import React from "react";
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
                            url: `/api/bids/${currentElem.bidId}`
                        }).done(() => {
                            const updatedElem = that.getRequestById(currentElem.id);
                            updatedElem.doesProposalBelongToCurrentUser = false;
                            updatedElem.currentInvestorProposal = "";
                            updatedElem.bidId = 0;

                            const updatedRequests = Object.assign(that.state.requests, { requests: updatedElem });
                            that.setState({ requests: updatedRequests });

                        }).fail((xhr, ajaxOptions, thrownError) => {
                            that.errorHandler(xhr, ajaxOptions, thrownError);
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
            investorBidValue: currentElem.currentInvestorProposal
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
                            url: "/api/bids"
                        }).done((createdBid) => {
                            console.log(createdBid);
                            const updatedElem = that.getRequestById(currentElem.id);
                            updatedElem.doesProposalBelongToCurrentUser = true;
                            updatedElem.bidId = createdBid.id;

                            const updatedRequests = Object.assign(that.state.requests, { requests: updatedElem });
                            that.setState({ requests: updatedRequests });
                        }).fail((xhr, ajaxOptions, thrownError) => {
                            that.errorHandler(xhr, ajaxOptions, thrownError);
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

        currentElem.currentInvestorProposal = event.target.value;

        this.setState({ requests: this.state.requests });
    }

    componentDidMount() {
        const that = this;

        $.ajax({
            method: "GET",
            cache: false,
            async: true,
            url: "/api/loanRequests"
        }).done(data => {
            if (data && data.length > 0) {
                const requests = data.map((i => {
                    if (i.currentInvestorProposal) {
                        i.doesProposalBelongToCurrentUser = true;
                    }
                    return i;
                }));

                that.setState({ requests: requests })
            }

        }).fail((xhr, ajaxOptions, thrownError) => {
            alert(xhr.status);
            alert(thrownError);
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
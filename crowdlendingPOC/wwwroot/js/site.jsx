
const Request = (propValues) => {

    const props = propValues.data;
    const purposeVal = props.purpose || "";
    var purpose = purposeVal.toString().substr(0, 100) + "...";
   
    const amountBtn = (props.doesCurrentInvestorAmountExist
        ? 
        <button
            type="button"
            className="btn btn-default"
            onClick={(e) => propValues.investorAmountClickRemoveHandler(props.id, e)}>
            <span className="glyphicon glyphicon-remove"></span>
        </button>
        :
        <button
            type="button"
            className="btn btn-default"
            disabled={!props.currentInvestorAmount}
            onClick={(e) => propValues.investorAmountClickAddHandler(props.id, e)}>
            <span className="glyphicon glyphicon-ok">
            </span>
        </button>
    );

    const interestRateControl = (props.isInterestRateAttractive
        ? <label>
            Interest Rate:
            <div className="form-element-value text-primary"><strong>{props.interestRate}</strong></div>
          </label>
        : <label>
            Interest Rate:
            <div className="form-element-value">{props.interestRate}</div>
           </label>
    );

    return (
        <div className="request-element">
            <div className="panel panel-default">
                <div className="panel-heading">
                    <strong className="panel-title">{props.amountRequest} {props.currency}</strong>
                </div>
                <div className="panel-body">
                    <div className="form-group">
                        <label>
                            Credit Seeker:
                            <div className="form-element-value">{props.creditSeekerName}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        {interestRateControl}
                    </div>
                    <div className="form-group">
                        <label>
                            Purpose:
                            <div className="form-element-value"
                                title={purposeVal}>{purpose}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Repayment Start Date:
                            <div className="form-element-value">{props.repaymentStartDate}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Repayment End Date:
                            <div className="form-element-value">{props.repaymentEndDate}</div>
                        </label>
                    </div>
                    <div className="input-group">
                        <input type="text"
                            placeholder="100 - 10000"
                            className="form-control"
                            value={props.currentInvestorAmount || ""}
                            onChange={(e) => propValues.investorAmountHandler(props.id, e)} />
                            <span className="input-group-btn">
                                {amountBtn}
                            </span>
                    </div>
                </div>
            </div>
        </div>
    );

};

const Requests = (props) => {

    const requests = props.requests.map((item, idx) => {
        return (
            <Request
                data={item}
                key={idx}
                investorAmountHandler={props.investorAmountHandler}
                investorAmountClickAddHandler={props.investorAmountClickAddHandler}
                investorAmountClickRemoveHandler={props.investorAmountClickRemoveHandler}/>
            )
    });

    return (<div className="row">{requests}</div>);

};


class App extends React.Component {
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
                investorAmountClickRemoveHandler={this.investorAmountClickRemoveHandler}/></div>
        )
    }

}

ReactDOM.render(<App />, document.getElementById("root"));


const Request = (propValues) => {

    const props = propValues.data;
    const purposeVal = props.purpose || "";
    var purpose = purposeVal.toString().substr(0, 100) + "...";

    var hasCurrentInvestorAmount = true;
    //props.currentInvestorAmount
    const amountBtn = (hasCurrentInvestorAmount ? 
        <button
            type="button"
            className="btn btn-sm"
            aria-label="Left Align"
            onClick={(e) => propValues.investorAmountClickAddHandler(props.id, e)}>

            <span className="glyphicon glyphicon-ok test-success" aria-hidden="true"></span>
        </button> : 
        
        
        <button
            type="button"
            className="btn btn-sm"
            aria-label="Left Align"
            onClick={(e) => propValues.investorAmountClickRemoveHandler(props.id, e)}>

            <span className="glyphicon glyphicon-remove text-danger" aria-hidden="true"></span>
        </button>
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
                            Credit Seeker
                            <div className="form-element-value">{props.creditSeekerName}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Interest Rate
                            <div className="form-element-value">{props.interestRate}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Purpose
                            <div className="form-element-value">{purpose}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Repayment Start Date
                            <div className="form-element-value">{props.repaymentStartDate}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Repayment End Date
                            <div className="form-element-value">{props.repaymentEndDate}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Your Bid
                            <input
                                value={props.currentInvestorAmount || ""}
                                onChange={(e) => propValues.investorAmountHandler(props.id, e)} />
                            {amountBtn}
                        </label>
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
                investorAmountClickAddHandler={props.investorAmountClickAddHandler}/>
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


        this.state = initialState;

    }

    investorAmountClickAddHandler(id, event) {
        event.preventDefault();
        const currentElem = this.getRequestById(id);
        const data = JSON.stringify({
            loanRequestId: currentElem.id,
            currentInvestorAmount: currentElem.currentInvestorAmount
        });
        const that = this;
        $.ajax({
            method: "POST",
            cache: false,
            data: data,
            async: true,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: "api/bids/PostBid",
            success: (data) => {
                debugger;                
            },
            error: (xhr, ajaxOptions, thrownError) => {
                this.errorHandler(xhr, ajaxOptions, thrownError);
            }
        });
    }

    errorHandler(x, status, error) {
        alert(status + ": " + error);
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
                that.setState({requests: data})
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
                investorAmountClickAddHandler={this.investorAmountClickAddHandler}/></div>
        )
    }

}

ReactDOM.render(<App />, document.getElementById("root"));


const Request = (propValues) => {

    const props = propValues.data;
    const purposeVal = props.purpose || "";
    var purpose = purposeVal.toString().substr(0, 100) + "...";
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
                            <div>{props.creditSeekerName}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Interest Rate
                            <div>{props.interestRate}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Purpose
                            <div>{purpose}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Repayment Start Date
                            <div>{props.repaymentStartDate}</div>
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            Repayment End Date
                            <div>{props.repaymentEndDate}</div>
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
                key={idx} />
            )
    });
        
    return (<div>{ requests }</div>);

};


class App extends React.Component {
    constructor() {
        super();
        const initialState = {
            requests: []
        }

        this.state = initialState;

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
            <div><Requests requests={this.state.requests}/></div>
        )
    }

}

ReactDOM.render(<App />, document.getElementById("root"));

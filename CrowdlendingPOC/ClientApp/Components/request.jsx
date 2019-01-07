import React from "react";

export const Request = (propValues) => {

    const props = propValues.data;
    const purposeVal = props.purpose || "";
    var purpose = purposeVal.toString().substr(0, 100) + "...";

    const amountBtn = (props.doesProposalBelongToCurrentUser
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
            disabled={!props.currentInvestorProposal}
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
                            value={props.currentInvestorProposal || ""}
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


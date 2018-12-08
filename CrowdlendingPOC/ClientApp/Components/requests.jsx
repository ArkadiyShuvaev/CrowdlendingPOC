import React from "react";
import { Request } from "./request";

export const Requests = (props) => {

    const requests = props.requests.map((item, idx) => {
        return (
            <Request
                data={item}
                key={idx}
                investorAmountHandler={props.investorAmountHandler}
                investorAmountClickAddHandler={props.investorAmountClickAddHandler}
                investorAmountClickRemoveHandler={props.investorAmountClickRemoveHandler} />
        )
    });

    return (<div className="row">{requests}</div>);

};

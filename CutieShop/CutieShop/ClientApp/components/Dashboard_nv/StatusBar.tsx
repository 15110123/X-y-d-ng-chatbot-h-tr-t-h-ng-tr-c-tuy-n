import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import "../../css/DashBoardNv/StatusBar.css"

export class StatusBar extends React.Component<{StatusOrder: number}, {}> {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <ol className="progtrckr" data-progtrckr-steps="3">
                {
                    <li className={"progtrckr-" +  (this.props.StatusOrder == 0 ? "done" : "todo")}>Đang tiếp nhận đơn hàng</li>
                }
                {
                    <li className={"progtrckr-" +  (this.props.StatusOrder == 1 ? "done" : "todo")}>Đã tiếp nhận đơn hàng</li>
                }
                {
                    <li className={"progtrckr-" +  (this.props.StatusOrder == 2 ? "done" : "todo")}>Đã giao hàng</li>
                }
                </ol>
            </div>
            );
    }
}
import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import "../../css/DashBoardNv/WarningBanner.css"

export class WarningBanner extends React.Component<{ warn: boolean }, {}> {

    constructor(props) {
        super(props)
    }
    render() {
        if (!this.props.warn) {
            return null;
        }

        else {
            return (
                <div className="warningBanner warning">
                    <h2>Bạn không có quyền truy cập vào khu vực này!</h2>
                </div>
            );
        }
    }
}
import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import "../../css/DashBoardNv/TrackOrderStatus.css"
import {MainPageTrackOrder} from "./MainPageTrackOrder"

export class TrackOrderStatus extends React.Component<{ OrderID: number, host: MainPageTrackOrder }, {redirect: boolean}> {
    constructor(props) {
        super(props);
        this.handleReturn = this.handleReturn.bind(this);
    }

    handleReturn() {
        //window.history.back();
        this.props.host.goBack();
    }

    render() {
        return (
            <div>
                <div className="center-content">
                    <h3 id="titlePageTrackOrder">Danh sách chi tiết đơn hàng số {this.props.OrderID}</h3>
                    <div id="return">
                        <a onClick={this.handleReturn}>Quay lại</a>
                    </div>
                    <div>
                        <table>
                            <thead>
                                <tr>
                                    <th>Sản phẩm</th>
                                    <th>Số lượng</th>
                                    <th>Tổng tiền</th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.renderTr("Con Heo Đất", "20", "1.200.000")}
                                {this.renderTr("Con Heo Đất", "20", "1.200.000")}
                                {this.renderTr("Con Heo Đất", "20", "1.200.000")}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            );
    }

    renderTr(productName, quantity, totalPrice) {
        return (
            <tr>
                <td><a>{productName}</a></td>
                <td>{quantity}</td>
                <td>{totalPrice}</td>
            </tr>
            );
    }
}
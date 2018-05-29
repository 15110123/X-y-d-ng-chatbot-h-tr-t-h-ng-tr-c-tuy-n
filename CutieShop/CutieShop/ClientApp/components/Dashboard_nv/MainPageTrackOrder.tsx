import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import $ from "jquery";
import "../../css/DashBoardNv/MainPageTrackOrder.css"
import { StatusBar } from './StatusBar';
import { TrackOrderStatus } from './TrackOrderStatus';
import RequestUtils from "../../models/utils/RequestUtils"

export class MainPageTrackOrder extends React.Component<{}, { isShowStatusBar: Boolean, value: string, tableShow: number, onlineOrderArr: any }> {

    
    constructor(props) {
        super(props);
        this.renderTr = this.renderTr.bind(this);
        this.renderTable = this.renderTable.bind(this);

        RequestUtils.sendRequest("/api/onlineorder/all", [], "GET", (o) => {
            this.state = {isShowStatusBar: false, value: "Đang tiếp nhận đơn hàng", tableShow: 0, onlineOrderArr: o};
        });

        // this.state = {isShowStatusBar: false, value: "Đang tiếp nhận đơn hàng", tableShow: 0, onlineOrderArr: [
        //     {onlineOrderId: 123, date: "1/4/2016", totalPrice: 30000}
        // ]};
    }

    goBack(){
        this.setState({isShowStatusBar: false, tableShow: 0});
    }

    render() {
        return (
            <div>
                <div className="center-content">
                    <h3 id="titlePageTrackOrder">Danh sách đơn hàng</h3>
                    {
                        this.state.isShowStatusBar && (
                            <StatusBar StatusOrder={1}/>
                        )
                    }
                </div>
                {this.renderTable("0124")}
            </div>
            );
    }

    renderTr(productId, orderDate, totalPrice){
        return <tr className="clickShowStatus" onClick={() => { this.setState({ isShowStatusBar: true }) }}>
            <td><a id="orderid" onClick={() => { this.setState({ tableShow: 1}) }}>{productId}</a></td>
                                <td>{orderDate}</td>
                                <td>{totalPrice}</td>
                                <td>
                                <select className="changeStatus">
                                    <option>Đang tiếp nhận đơn hàng</option>
                                    <option>Đã tiếp nhận đơn hàng</option>
                                    <option>Đã giao hàng</option>
                                </select>
                                </td>
                            </tr>;
    }

    renderTable(onlineOrderId) {
        if (this.state.tableShow != 1)
            return (
                <div>
                    <table>
                        <thead>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Ngày đặt hàng</th>
                                <th>Tổng thanh toán</th>
                                <th>Trạng thái</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.onlineOrderArr.map(ele => {
                                    return this.renderTr(ele.onlineOrderId, ele.date, ele.totalPrice);
                                })
                            }
                            {/*
                            {this.renderTr("0124", "01-08-2018", "1.200.000")}
                            {this.renderTr("0124", "01-08-2018", "1.200.000")}
                            {this.renderTr("0124", "01-08-2018", "1.200.000")}
                            */}
                        </tbody>
                    </table>
                </div>
            );
        else
            return (
                <TrackOrderStatus OrderID={onlineOrderId} host={this}/>
                );
    }
}
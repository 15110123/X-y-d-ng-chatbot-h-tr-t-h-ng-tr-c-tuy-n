import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import "../../css/DashBoardNv/ContentDashboard.css"
import $ from "jquery"
import { TrackOrderStatus } from './TrackOrderStatus';
import { ExportReports } from './ExportReports';
import { MainPageTrackOrder } from './MainPageTrackOrder';

export class ContentDashboard extends React.Component<{ Show: boolean }, {contentComponent: string}> {
    constructor(props) {
        super(props);
        this.state = { contentComponent: "MainPageTrackOrder" };
        this.exportReports = this.exportReports.bind(this);
        this.mainPageTrackOrderStatus = this.mainPageTrackOrderStatus.bind(this);
    }

    mainPageTrackOrderStatus() {
        this.setState({ contentComponent: "MainPageTrackOrder" });
    }

    exportReports() {
        this.setState({ contentComponent: "ExportReports" });
    }


    
    render() {

        const component = this.state.contentComponent != "MainPageTrackOrder" ? (<ExportReports />) : (<MainPageTrackOrder />);
        if (!this.props.Show)
            return null;
        else {
            return (
                <div className="contentDashboard">
                    <h1>Dashboard Cutie Shop</h1>
                    <div className="container">
                    <div className="row">
                    <div className="col-md-3 vertical-menu-container">
                    <div className="vertical-menu">
                                    <a className="active">Chức năng</a>
                                    <a onClick={this.mainPageTrackOrderStatus}>Theo dõi tình trạng đơn hàng</a>
                                    <a onClick={this.exportReports}>Xuất báo cáo nhập</a>
                    </div>
                    </div>
                    <div className="col-md-9">
                                <div className="main">
                                    {component}
                    </div>
                    </div>
                    </div>
                    </div>
                </div>
            );
        }
    }
}
//ReSharper disable All
import * as React from 'react';
import { ChatBox } from "./ChatBox/ChatBox";
import { Header } from "./LayoutComponents/Header"
import { Drawer } from "./LayoutComponents/Drawer/Drawer"
import { LinkBar } from "./LayoutComponents/LinkBar"
import { LoginDialog } from "./Dialog/LoginDialog/LoginDialog"
import "../css/DashBoardNv/ContentDashboard.css"

export interface LayoutProps {
    children?: React.ReactNode;
}

export class DashboardLayout extends React.Component<LayoutProps, {}> {
    drawer: any;
    loginDialog: any;

    constructor(props) {
        super(props);
    }

    public render() {
        return <div>
            <div className="sidenav">
                <a>Xuất báo cáo nhập</a>
                <a>Theo dõi tình trạng đơn hàng</a>
            </div>
            {this.props.children}
        </div>
    }
}

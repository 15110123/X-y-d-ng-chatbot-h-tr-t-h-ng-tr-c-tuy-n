import * as React from "react"
import "../../css/LinkBar/linkbar.css"
import { Link } from "react-router-dom"

export class LinkBar extends React.Component<{ drawerBtnClick?: Function, loginLinkClick?: Function, isLoggedIn: boolean }, {}> {

    constructor(props) {
        super(props);
        this.drawerBtnClick = this.drawerBtnClick.bind(this);
        this.loginLinkClick = this.loginLinkClick.bind(this);
    }

    render() {
        return <div id="stickyBar">
            <span id="linkGroup">
                <a href="#">Giới thiệu</a>
                |
                       <a href="#">Bài viết</a>
                |
                       <a href="#">Liên hệ</a>
            </span>
            {this.props.isLoggedIn ? this.renderLoggedIn() : this.renderNotLoggedIn()}
        </div>;
    }

    renderLoggedIn() {
        return <span id="profileBar">
            <label>Chào bạn {window.user.name}!</label>
            <img src={window.user.profileImg} alt="Profile image" />
            <label id="drawerBtn" onClick={this.drawerBtnClick}>&#9776;</label>
        </span>;
    }

    renderNotLoggedIn() {
        return <span id="profileBar">
            <a href="#" onClick={this.loginLinkClick}>Đăng nhập</a>
        </span>;
    }

    drawerBtnClick() {
        if (this.props.drawerBtnClick == null) return;
        this.props.drawerBtnClick();
    }

    loginLinkClick(o) {
        o.preventDefault();
        if (this.props.loginLinkClick == null) return;
        this.props.loginLinkClick();
    }
}
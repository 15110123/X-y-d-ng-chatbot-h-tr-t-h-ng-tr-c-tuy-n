import * as React from "react"
import "../../../css/Drawer/drawerprofile.css"
import cookies from "js-cookie"
import * as $ from "jquery"

export class DrawerProfile extends React.Component<{imgUrl : string}, {}> {
    constructor(props) {
        super(props);
        this.logoutClickHandler = this.logoutClickHandler.bind(this);
    }

    render() {
        return <div id="drawerProfile">
            <img id="profileImg" src={this.props.imgUrl} alt="Profile image"/>
                   <span id="profileInfo">
                       <label id="profileName">{window.user.user.firstName}</label>
                       <label id="profilePoint">{window.user.user.point} điểm</label>
                   </span>
                   <div id="profileLink">
                       <div className="profileLinkWrapper">
                    <a href="#" onClick={this.logoutClickHandler}>Đăng xuất</a>
                       </div>
                   </div>
               </div>;
    }

    logoutClickHandler() {
        //Cookie remove
        cookies.remove("sessionId");

        //Session remove

        const sessionSettings = {
            "async": false,
            "crossDomain": true,
            "url": "/removesession",
            "method": "POST",
            "headers": {
                "Cache-Control": "no-cache"
            },
            "processData": false,
            "contentType": false,
            "mimeType": "multipart/form-data",
            "data": ""
        };

        $.ajax(sessionSettings);

        window.location.pathname = "/";
    }
}
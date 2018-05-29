import * as React from "react"
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider"
import Dialog from "material-ui/Dialog"
import FlatButton from "material-ui/FlatButton"
import TextField from "material-ui/TextField"
import "../../../css/Dialogs/logindialog.css"
import Checkbox from "material-ui/Checkbox"
import * as $ from "jquery"
import Snackbar from "material-ui/Snackbar";
import Cookies from "js-cookie";
import RequestUtils from "../../../models/utils/RequestUtils";

export class LoginDialog extends React.Component<{ loginSuccessHandler?: Function, open: boolean }, { isOpen: boolean, isSaveLoginCheck: boolean, isSuccess: boolean | null }> {
    actions;

    username: string;
    password: string;

    constructor(props) {
        super(props);

        this.username = "";
        this.password = "";

        this.state = { isOpen: this.props.open, isSaveLoginCheck: false, isSuccess: null };
        this.loginClickHandler = this.loginClickHandler.bind(this);
        this.toggleDialogHandler = this.toggleDialogHandler.bind(this);
        this.updateCheckHandler = this.updateCheckHandler.bind(this);
        this.updateUsernameHandler = this.updateUsernameHandler.bind(this);
        this.updatePasswordHandler = this.updatePasswordHandler.bind(this);
        this.snackBarCloseHandler = this.snackBarCloseHandler.bind(this);

        this.actions = [
            <FlatButton
                label="Đăng nhập"
                primary={true}
                onClick={this.loginClickHandler} />
        ];
    }

    render() {
        return <div>
            <MuiThemeProvider>
                <Snackbar
                    open={this.state.isSuccess != null && !this.state.isSuccess}
                    message="Đăng nhập thất bại"
                    autoHideDuration={4000}
                    onRequestClose={this.snackBarCloseHandler}/>
            </MuiThemeProvider>
            <MuiThemeProvider>
                <Dialog title="Đăng nhập" actions={this.actions} modal={false} open={this.state.isOpen} onRequestClose={
                    this.toggleDialogHandler} paperClassName="loginDialog">
                    {this.renderTextField("Tên đăng nhập", false, this.updateUsernameHandler)}
                    {this.renderTextField("Mật khẩu", true, this.updatePasswordHandler)}
                    {this.renderCheckBox("Duy trì đăng nhập")}
                </Dialog>
            </MuiThemeProvider>;
               </div>;
    }

    //Method for rendering text field with same style
    renderTextField(label, isPassword, onChange) {
        const fieldType = isPassword ? "password" : "text";
        return <TextField floatingLabelText={label} type={fieldType} fullWidth={true
        } className="loginTextField" underlineFocusStyle={{ borderColor: "#1B5E20" }} floatingLabelFocusStyle={
            { color: "#1B5E20" }} underlineStyle={{ borderColor: "#616161" }} onChange={onChange} />;
    }

    renderCheckBox(label) {
        return <Checkbox label={label} checked={this.state.isSaveLoginCheck} onCheck={this.updateCheckHandler} />;
    }

    snackBarCloseHandler() {
        this.setState({ isSuccess: null });
    }

    updateCheckHandler() {
        this.setState({ isSaveLoginCheck: !this.state.isSaveLoginCheck });
    }

    updateUsernameHandler(o, v) {
        this.username = v;
    }

    updatePasswordHandler(o, v) {
        this.password = v;
    }

    toggleDialogHandler() {
        this.setState({ isOpen: !this.state.isOpen });
    }

    loginClickHandler() {
        //Add "checking auth" codes here 

    RequestUtils.sendRequest("/api/auth", [["username", this.username], ["password", this.password]], "POST", o => {
        let res = o;
        if (res == null) {
            this.setState({ isSuccess: false });
            return;
        }

        //Success
        if (this.state.isSaveLoginCheck) {
            Cookies.set("sessionId",
                res.sessionId,
                {
                    expires: 30
                });
        } else {
            const sessionForm = new FormData();
            sessionForm.append("sessionId", res.sessionId);

            const sessionSettings = {
                "async": false,
                "crossDomain": true,
                "url": "/savesession",
                "method": "POST",
                "headers": {
                    "Cache-Control": "no-cache"
                },
                "processData": false,
                "contentType": false,
                "mimeType": "multipart/form-data",
                "data": sessionForm
            };

            $.ajax(sessionSettings);
        }
        this.setState({ isSuccess: true });

        this.toggleDialogHandler();
        //Testing profile 
        window.user = res;
        if (this.props.loginSuccessHandler == null) return;
        this.props.loginSuccessHandler();
    });
        //const form = new FormData();
        //form.append("username", this.username);
        //form.append("password", this.password);

        //const settings = {
        //    "async": false,
        //    "crossDomain": true,
        //    "url": window.dbAPI + "/api/auth",
        //    "method": "POST",
        //    "headers": {
        //        "Cache-Control": "no-cache"
        //    },
        //    "processData": false,
        //    "contentType": false,
        //    "mimeType": "multipart/form-data",
        //    "data": form
        //};

        //const res = JSON.parse($.ajax(settings).responseText);

        //Fail login
    }
}
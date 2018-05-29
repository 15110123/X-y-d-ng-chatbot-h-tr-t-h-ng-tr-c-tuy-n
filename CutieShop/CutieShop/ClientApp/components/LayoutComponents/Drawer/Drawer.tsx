//ReSharper disable All
import * as React from "react";
import MuiDrawer from "material-ui/Drawer";
import MuiMenuItem from "material-ui/MenuItem";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";
import { DrawerProfile } from "./DrawerProfile";
import "./../../../css/Drawer/drawer.css";

export class Drawer extends React.Component<{}, { isOpen: boolean }> {
  constructor(props) {
    super(props);
    this.state = { isOpen: false };
    this.toggleDrawerHandler = this.toggleDrawerHandler.bind(this);
  }

  render() {
    return (
      <MuiThemeProvider>
        <MuiDrawer
          docked={false}
          width={300}
          open={this.state.isOpen}
          onRequestChange={this.toggleDrawerHandler}
          openSecondary={true}
          className="muiDrawer"
        >
          <DrawerProfile imgUrl="https://cloud.netlifyusercontent.com/assets/344dbf88-fdf9-42bb-adb4-46f01eedd629/68dd54ca-60cf-4ef7-898b-26d7cbe48ec7/10-dithering-opt.jpg" />
          <MuiMenuItem className="muiMenuItem">Thông tin tài khoản</MuiMenuItem>
          <MuiMenuItem className="muiMenuItem">Giỏ hàng</MuiMenuItem>
          <MuiMenuItem className="muiMenuItem">Đăng kí dịch vụ</MuiMenuItem>
        </MuiDrawer>
      </MuiThemeProvider>
    );
  }

  toggleDrawerHandler() {
    this.setState({ isOpen: !this.state.isOpen });
  }
}

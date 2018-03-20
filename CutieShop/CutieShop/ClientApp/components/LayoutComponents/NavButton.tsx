import * as React from "react"
import "../../css/NavButton/navbutton.css"

export class NavButton extends React.Component<{ name: string, icon : string}, {}> {
    constructor(props) {
        super(props);
    }

    render() {
        return <div className="Dropdown">
            <button className="BtnNav">
                <img className="navBtnIcon" alt="Navigation button icon" src={this.props.icon}/>
                <label>
                    {this.props.name}
                </label>
            </button>
            <div className="Dropdown-content">
                {this.props.children}
            </div>
        </div>;
    }
}
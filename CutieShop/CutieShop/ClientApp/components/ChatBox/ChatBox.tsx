//ReSharper disable All
import * as React from "react"
import "../../css/ChatBox/chatbox.css"
import ElementUtil from "../../ElementUtil"

export class ChatBox extends React.Component<{}, {}> {
    public constructor(props) {
        super(props);
    }

    public render() {
        return <div id="chatbox-container" className="hover-fx">
            <div id="chatbox-main" style={{ display: "none"}}>
                <div id="chatbox-form-container">
                    {
/*Changed: using Facebook messenger instead of custom one*/
/*
                           <form id="chatbox-form">
                        <textarea id="chatbox-form-input" form="chatbox-form" name="message" rows={1}></textarea>
                        </form>
                        */}
                       </div>
                   </div>
                   <div id="chatbox-footer">
                       <span id="chatbox-icon-container">
                    <img id="chatbox-icon" src="/img/svg/ChatBoxIcon.svg"/>
                       </span>
                       <span id="chatbox-label-container">
                           <label>Hãy chat với chúng mình!</label>
                       </span>
                   </div>
               </div>
    }

    componentDidMount() {
        ElementUtil.addScript("chatbox.js");
    }
}
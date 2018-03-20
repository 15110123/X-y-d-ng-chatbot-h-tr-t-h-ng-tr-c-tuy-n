import * as React from "react"
import { Redirect } from 'react-router'
import "../../css/Header/header.css"
import { NavBar } from "./NavBar"
export class Header extends React.Component<{}, { doneSearch: boolean, keyword: string }> {
    constructor(props) {
        super(props);
        this.state = { doneSearch: false, keyword: "" };

        //This binding
        this.submitHandler = this.submitHandler.bind(this);
        this.keywordChangeHandler = this.keywordChangeHandler.bind(this);
    }

    render() {
        return <div id="header">
            <div id="logo">
                <img src="/img/svg/Logo.svg" id="imgLogo" />
            </div>
            <div id="logoText">
                <label>Thế giới thú cưng</label>
            </div>
            <div id="searchBar">
                <div id="searchInput">
                    <button id="submitBtn" form="SearchForm"></button>
                    <form method="GET" id="SearchForm" onSubmit={this.submitHandler}>
                        <input name="keyword" id="searchText" placeholder="banh chạy, lồng mica, dây xích chó,..." onChange={this.keywordChangeHandler} />
                        {/*Redirect after form submit*/}
                        {this.state.doneSearch && (<Redirect to={`/search?keyword=${this.state.keyword}`}/>)}
                    </form>
                </div>
            </div>
            <NavBar />
        </div>;
    }

    submitHandler(e) {
        e.preventDefault();
        this.setState({ doneSearch: true });
    }

    keywordChangeHandler(e) {
        this.setState({ doneSearch: false, keyword: e.target.value });
    }
}
//ReSharper disable All
import * as React from "react"
import {RouteComponentProps, Redirect} from "react-router"
import {ProductCard} from "./ProductCard"
import "../../css/Search/search.css"

export class Search extends React.Component<RouteComponentProps<{}>, {keyword : string}> 
{
    constructor(props) {
        super(props);
        let params = new URLSearchParams(this.props.location.search);
        this.state = { keyword: params.get("keyword") as string };
    }

    render() {
        return <div className="SearchContainer">
            <label>Bạn vừa tìm {this.state.keyword}</label><br/>
            <div className="row">
            <div className="col-lg-3">
            <ProductCard Name="Hamster Winter White" Price={200000} Unit="VNĐ" ImgUrl="http://dwarfhamsterhome.com/wp-content/uploads/2016/01/winter-white-dwarf.jpg"/>
            </div>
            <div className="col-lg-3">
            <ProductCard Name="Hamster Winter White" Price={200000} Unit="VNĐ" ImgUrl="http://dwarfhamsterhome.com/wp-content/uploads/2016/01/winter-white-dwarf.jpg"/>
            </div>
            <div className="col-lg-3">
            <ProductCard Name="Hamster Winter White" Price={200000} Unit="VNĐ" ImgUrl="http://dwarfhamsterhome.com/wp-content/uploads/2016/01/winter-white-dwarf.jpg"/>
            </div>
            <div className="col-lg-3">
            <ProductCard Name="Hamster Winter White" Price={200000} Unit="VNĐ" ImgUrl="http://dwarfhamsterhome.com/wp-content/uploads/2016/01/winter-white-dwarf.jpg"/>
            </div>
            <div className="col-lg-3">
            <ProductCard Name="Hamster Winter White" Price={200000} Unit="VNĐ" ImgUrl="http://dwarfhamsterhome.com/wp-content/uploads/2016/01/winter-white-dwarf.jpg"/>
            </div>
            </div>
        </div>;
    }    

    componentWillReceiveProps(newProps) {
        let params = new URLSearchParams(newProps.location.search);
        let keyword = params.get("keyword") as string;

        if (keyword == "") {
            window.location.pathname = "/";
            return;
        }

        this.setState({ keyword: keyword });
    }
}
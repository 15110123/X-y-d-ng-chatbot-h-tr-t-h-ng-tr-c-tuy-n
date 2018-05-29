//ReSharper disable All
import * as React from "react"
import { RouteComponentProps, Redirect } from "react-router"
import { ProductCard } from "./ProductCard"
import "../../css/Search/search.css"
import RequestUtils from "../../models/utils/RequestUtils"

export class Search extends React.Component<RouteComponentProps<{}>, { keyword: string }>
{
    private searchResArr: any = [{name: "Hamster winter white", price: 150000, imgUrl:"http://4.bp.blogspot.com/-WsBmyAoHD0I/T9G7XvxoAjI/AAAAAAAACBQ/0ucXCTZNn64/s1600/hamster.jpg"}];

    constructor(props) {
        super(props);
        let params = new URLSearchParams(this.props.location.search);
        this.state = { keyword: params.get("keyword") as string };
    }

    render() {
        return <div className="SearchContainer">
            <label>Bạn vừa tìm {this.state.keyword}</label><br />
            <div className="row">

                {
                    this.state.keyword && this.searchResArr.map(ele => {
                        return <div className="col-lg-3">
                            <ProductCard Name={ele.name}
                                Price={ele.price}
                                Unit="VNĐ"
                                ImgUrl={ele.imgUrl} />
                        </div>
                    })
                }
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

        this.searchResArr = RequestUtils.sendRequest("/search", [["keyword", keyword]], "GET");

        this.setState({ keyword: keyword });
    }
}
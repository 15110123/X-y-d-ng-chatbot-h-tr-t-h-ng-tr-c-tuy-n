import * as React from "react"
import {NumberConvertUtil} from "../../models/utils/ConvertUtils"
import "../../css/Search/Productcard.css"

export class ProductCard extends React.Component<{ Name: string, Price: number, Unit: string, ImgUrl: string}, {}>{
    constructor(props) {
        super(props);
    }

    render() {
        return <div className="ProductCard">
            <div className="CirclePic">
                <div className="BackgroundCircle1"></div>
                <div className="BackgroundCircle2"></div>
                <img src={this.props.ImgUrl} />
            </div>
            <div className="PriceTag">
                <label>{NumberConvertUtil.numberToPrice(this.props.Price, this.props.Unit)}</label>
            </div>
            <div className="ProductFooter">
                <div className="ProductName">
                    <label>{this.props.Name}</label>
                </div>
                <div className="BtnBuy">
                    <img src="/img/svg/BuyIcon.svg" />
                </div>
            </div>
        </div>;
    }
}
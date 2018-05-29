//ReSharper disable All
import * as React from "react";
import { RouteComponentProps, Redirect } from "react-router";
import { ProductCard } from "./ProductCard";
import "../../css/Search/search.css";
import RequestUtils from "../../models/utils/RequestUtils";

export class Search extends React.Component<
  RouteComponentProps<{}>,
  {
    keyword: string;
    searchResArr: any;
    selectedProductType: number;
    selectedPetType: string;
    petTypeArr: any;
    productTypeArr: any;
  }
> {
  //private searchResArr: any = [{name: "Hamster winter white", price: 150000, imgUrl:"http://4.bp.blogspot.com/-WsBmyAoHD0I/T9G7XvxoAjI/AAAAAAAACBQ/0ucXCTZNn64/s1600/hamster.jpg"}];

  constructor(props) {
    super(props);
    let params = new URLSearchParams(this.props.location.search);
    let keyword = params.get("keyword") as string;

    this.state = {
      keyword: keyword,
      searchResArr: [],
      selectedPetType: "",
      selectedProductType: -1,
      petTypeArr: [],
      productTypeArr: [
        { id: "0", name: "Phụ kiện" },
        { id: "1", name: "Chuồng nuôi" },
        { id: "2", name: "Thú cưng" },
        { id: "3", name: "Dịch vụ" },
        { id: "4", name: "Đồ chơi" },
        { id: "5", name: "Thức ăn" }
      ]
    };

    RequestUtils.sendRequest(`/api/product/search/${keyword}`, [], "GET", o => {
      this.setState({
        searchResArr: o
      });
    });

    RequestUtils.sendRequest("/api/product/pet/all/type", [], "GET", o => {
      this.setState({ petTypeArr: o });
    });

    this.productTypeChanged = this.productTypeChanged.bind(this);
    this.petTypeChanged = this.petTypeChanged.bind(this);
  }

  render() {
    return (
      <div className="SearchContainer">
        <div className="container">
          <div className="row">
            <div className="col-md-3">
              <label>Loại sản phẩm</label>
              <select
                style={{ width: "200px" }}
                className="form-control"
                name="productTypeId"
                required={true}
                onChange={this.productTypeChanged}
              >
                <option
                  value="-1"
                  selected={this.state.selectedProductType == -1}
                >
                  Tất cả
                </option>
                {this.state.productTypeArr.map(ele => {
                  return (
                    <option
                      value={ele.id}
                      selected={this.state.selectedProductType == ele.id}
                    >
                      {ele.name}
                    </option>
                  );
                })}
              </select>
            </div>

            <div className="col-md-3">
              <label>Thú cưng</label>
              <select
                style={{ width: "200px" }}
                className="form-control"
                name="petTypeId"
                required={true}
                onChange={this.petTypeChanged}
              >
                <option value="" selected={this.state.selectedPetType == ""}>
                  Tất cả
                </option>
                {this.state.petTypeArr.map(ele => {
                  return (
                    <option
                      value={ele.petTypeId}
                      selected={this.state.selectedPetType == ele.petTypeId}
                    >
                      {ele.name}
                    </option>
                  );
                })}
              </select>
            </div>
          </div>
        </div>

        <label>Bạn vừa tìm {this.state.keyword}</label>
        <br />
        <div className="row">
          {this.state.keyword &&
            this.state.searchResArr.map(ele => {
              return (
                <div className="col-lg-3">
                  <ProductCard
                    Name={ele.name}
                    Price={ele.price}
                    Unit="VNĐ"
                    ImgUrl={ele.imgUrl}
                  />
                </div>
              );
            })}
        </div>
      </div>
    );
  }

  componentWillReceiveProps(newProps) {
    let params = new URLSearchParams(newProps.location.search);
    let keyword = params.get("keyword") as string;

    if (keyword == "") {
      window.location.pathname = "/";
      return;
    }

    RequestUtils.sendRequest(`/api/product/search/${keyword}`, [], "GET", o => {
      this.setState({
        keyword: keyword,
        searchResArr: o
      });
    });
  }

  productTypeChanged(o) {
    this.setState({ selectedProductType: o.target.value });
    this.startSearchWithFilter(o.target.value, this.state.selectedPetType);
  }

  petTypeChanged(o) {
    this.setState({ selectedPetType: o.target.value });
    this.startSearchWithFilter(this.state.selectedProductType, o.target.value);
  }

  startSearchWithFilter(localSelectedProductType: number, localSelectedPetType: string) {
    RequestUtils.sendRequest(
      `/api/product/search/filter/${this.state.keyword}`,
      [
        ["productType", localSelectedProductType.toString()],
        ["petType", localSelectedPetType]
      ],
      "GET",
      o => {
        this.setState({
          searchResArr: o
        });
      }
    );
  }
}

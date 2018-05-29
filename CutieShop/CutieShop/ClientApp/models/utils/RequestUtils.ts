import $ from "jquery";

export default class RequestUtils {
  static sendRequest(
    url: string,
    parameters: [string, string][],
    method: string,
    callBack: Function
  ) {
    try {
      let data = {};
      parameters.map(ele => {
        data[ele[0]] = ele[1];
      });

console.log(data);

      if (method == "GET")
        return $.get(window.location.origin + url, data).done(o => {
            //console.log(o);
            callBack(o);
        });

        return $.post(window.location.origin + url, data).done(o => {
            //console.log(o);
            callBack(o);
          });

      //return JSON.parse($.ajax(settings).responseText);
    } catch (e) {
      console.log("Có lỗi khi gửi request " + url);
      return null;
    }
  }
}

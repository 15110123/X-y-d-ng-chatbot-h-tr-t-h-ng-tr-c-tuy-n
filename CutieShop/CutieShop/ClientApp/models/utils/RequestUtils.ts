import $ from "jquery";

export default class RequestUtils {
    static sendRequest(url: string, parameters: [string, string][], method: string) {
        try {
            let form = new FormData();
            parameters.map(ele => {
                form.append(ele[0], ele[1]);
            });

            let settings = {
                "async": false,
                "crossDomain": true,
                //"url": window.location.origin + url,
                "url": "http://localhost:51992" + url,
                "method": method,
                "headers": {
                    "Cache-Control": "no-cache"
                },
                "processData": false,
                "contentType": false,
                "mimeType": "multipart/form-data",
                "data": form
            };

            return JSON.parse($.ajax(settings).responseText);
        } catch (e) {
            console.log("Có lỗi khi gửi request");
            return null;
        }
    }
}
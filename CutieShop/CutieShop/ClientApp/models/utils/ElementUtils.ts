export default class ElementUtils {
    static addScriptFromFile(jsFile: string, withVersionId:boolean) {
        const element = document.createElement("script");
        element.src = `/js/${jsFile}`;
        if (withVersionId) element.src += `?v=${this.guid()}`;
        document.body.appendChild(element);
    }

    static addScript(jsScript: string) {
        const element = document.createElement("script");
        element.innerHTML = jsScript;
        document.body.appendChild(element);
    }

    static guid() {
        return this.s4() + this.s4() + "-" + this.s4() + "-" + this.s4() + "-" + this.s4() + "-" + this.s4() + this.s4() + this.s4();
    }

    private static s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
}
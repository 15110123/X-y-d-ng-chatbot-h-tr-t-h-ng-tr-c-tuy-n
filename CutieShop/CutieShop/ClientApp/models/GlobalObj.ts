import { Layout as dashboardLayout } from "../components/Layout"
import cookies from "js-cookie"

declare global {
    interface Window {
        lstMem: any
    }
}

export class GlobalObj {
    static window: Window;
    static dashboardLayout: dashboardLayout | null;
    static empSessionId: string = cookies.get("empSessionId");
}
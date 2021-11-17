import { IComponentDetail } from "./componentDetail";

export interface IProcessRequest {
        id: number;
        userName: string;
        contactNumber: string;
        componentDetail: IComponentDetail;
        defectiveComponentDetailId: number;
    }



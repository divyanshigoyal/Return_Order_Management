import {v4 as uuidv4} from 'uuid'

export interface IComponentDetail {
    id: number;
    componentType: string;
    componentName: string;
    quantity: number;
}

export interface IProcessRequest {
    id: number;
    userName: string;
    contactNumber: string;
    componentDetail: IComponentDetail;
    defectiveComponentDetailId: number;
}

export class ProcessRequest implements IProcessRequest{
    id = uuidv4(); 
    userName: string;
    contactNumber: string;
    componentDetail: IComponentDetail;
    defectiveComponentDetailId: number;

}
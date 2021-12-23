    export interface ComponentDetail {
        id: number;
        componentType: string;
        componentName: string;
        quantity: number;
    }

    export interface RootObject {
        id: number;
        userName: string;
        contactNumber: string;
        componentDetail: ComponentDetail;
        defectiveComponentDetailId: number;
    }
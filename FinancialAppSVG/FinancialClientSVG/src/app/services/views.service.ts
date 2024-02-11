import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root',
})
export class ViewService {

    getViews() {
        return [
            { symbol: 'BTCUSDT', period: '30m' },
            { symbol: 'XRPUSDT', period: '1d' },
            { symbol: 'XRPUSDT', period: '1d' },
            { symbol: 'XRPUSDT', period: '1d' },
            { symbol: 'XRPUSDT', period: '1d' },
            { symbol: 'XRPUSDT', period: '1d' }
        ];
    }

    getSavedViews() {
        return [
            { id: 1, userId: 1, symbol: 'BTCUSDT', period: '30m' },
            { id: 2, userId: 2, symbol: 'XRPUSDT', period: '1d' },
            { id: 3, userId: 3, symbol: 'XRPUSDT', period: '1d' },
            { id: 4, userId: 4, symbol: 'XRPUSDT', period: '1d' },
            { id: 5, userId: 5, symbol: 'XRPUSDT', period: '1d' },
            { id: 5, userId: 6, symbol: 'XRPUSDT', period: '1d' }
        ];
    }
    getViewById(id: number) {
        // return this.getViews().find(view => view.id === id);
    }

    saveView(view: any) {
    }
    deleteView(id: number) {
        // call the api to delete the view
        // on success this.savedViews = this.savedViews.filter(v => v.id !== id);
    }
}
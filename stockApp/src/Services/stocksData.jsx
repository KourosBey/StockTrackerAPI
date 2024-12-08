import axios from 'axios';

class StockService {
    constructor() {
        this.BASE_URL = import.meta.env.VITE_API_URL;
    }

    async getAllStocks() {
        try {
            const response = await axios.get(`${this.BASE_URL}/stocks`);
            return response.data;
        } catch (error) {
            console.error('Error fetching stocks:', error);
            throw error;
        }
    }

    async addNewStock(newStock) {
        try {
            const response = await axios.post(`${this.BASE_URL}/stocks`, newStock);
            return response.data;
        } catch (error) {
            console.error('Error adding new stock:', error);
            throw error;
        }
    }

    async updateStock(stockId, updatedStock) {
        try {
            const response = await axios.put(`${this.BASE_URL}/stocks/${stockId}`, updatedStock);
            return response.data;
        } catch (error) {
            console.error('Error updating stock:', error);
            throw error;
        }
    }

    async deleteStock(stockId) {
        try {
            const response = await axios.delete(`${this.BASE_URL}/stocks/${stockId}`);
            return response.data;
        } catch (error) {
            console.error('Error deleting stock:', error);
            throw error;
        }
    }
}

export default new StockService();

import axios from 'axios';

class StockService {
    constructor() {
        this.BASE_URL = import.meta.env.VITE_API_URL;
    }

    async getAllStocks() {
        try {
            const response = await axios.get(`${this.BASE_URL}/Stock/get-stocks?page=0&size=20`);
            return response.data;
            // return response.data;
        } catch (error) {
            console.error('Error fetching stocks:', error);
            throw error;
        }
    }

    async addNewStock(newStock) {
        try {
            console.log('POST isteğiyle gönderilen veri:', newStock);
            const response = await axios.post(`${this.BASE_URL}/Stock/set-stock`, newStock, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });
            return response.data;
        } catch (error) {
            console.error('Error adding new stock:', error.response?.data || error.message);
            throw error;
        }
    }

    async updateStock(stockId, updatedStock) {
        try {
            // updatedStock nesnesinden id'yi kaldırarak gönderiyoruz.
            const { id, ...stockData } = updatedStock;

            const response = await axios.put(`${this.BASE_URL}/Stock/update-stock`, stockData);
            return response.data;
        } catch (error) {
            console.error('Stok güncellenirken hata oluştu:', error.response?.data || error.message);
            throw error;
        }
    }


    async deleteStock(stockId) {
        try {
            console.log('Gönderilen stockId:', stockId, typeof stockId); // Gönderilen ID'yi kontrol edin
            const response = await axios.delete(`${this.BASE_URL}/Stock/remove-stock?id=${stockId}`); // API isteği
            console.log('API Full Response:', response); // API'den gelen tam yanıtı loglayın
            return response.data; // Sadece "data" kısmını döndürün
        } catch (error) {
            console.error('Silme isteği sırasında hata oluştu:', error.response || error.message);
            throw error; // Hata fırlatılırsa `hadleDeleteStock` tarafından yakalanır
        }
    }

}

export default new StockService();

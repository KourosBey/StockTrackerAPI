import React, { useEffect, useState } from 'react';
import StockService from '../Services/stocksData';
import { DataGrid } from '@mui/x-data-grid';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import LoadingSpinner from '../components/LoadingSpinner';

const StockPage = () => {
    const [stocks, setStocks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [searchValue, setSearchValue] = useState('');
    const [filteredStocks, setFilteredStocks] = useState([]);
    const [openAddStock, setOpenAddStock] = useState(false);
    const [openSellStock, setOpenSellStock] = useState(false);
    const [sellStock, setSellStock] = useState({ stock_id: '', amount: 0 });
    const [editStock, setEditStock] = useState(null); // Düzenleme için seçilen stok
    const [openEditStock, setOpenEditStock] = useState(false);

    const [newStock, setNewStock] = useState({
        stockName: '',
        stockBarcode: '',
        stockCode: '',
        stockDescription: '',
        stockAmount: '',
        stockPrice: '',
    });

    useEffect(() => {
        fetchStocks();
    }, []);

    const fetchStocks = async () => {
        setLoading(true);
        try {
            const response = await StockService.getAllStocks();
            console.log("Backend Response:", response);

            if (response.isSuccess) {
                toast.success('Stoklar başarıyla getirildi.');
                const processedData = response.data.map(item => ({
                    id: item.id,
                    name: item.stockName || item.StockName || item.Stockname || 'No Name',
                    barcode: item.stockBarcode || item.StockBarcode || 'N/A',
                    code: item.stockCode || 'N/A',
                    description: item.stockDescription || 'No Description',
                    amount: item.stockAmount || 0,
                    salePrices: item.stockPrice || 0,
                    avaragePrices: item.stockPrice || 0,
                    createdTime: item.createdTime,
                }));

                console.log("Processed Data:", processedData);
                setStocks(processedData);
                setFilteredStocks(processedData);
            } else {
                toast.error(response.description || 'Stoklar getirilemedi.');
            }
        } catch (error) {
            console.error("Error fetching stocks:", error);
            toast.error('Stoklar getirilemedi. Lütfen tekrar deneyin.');
        } finally {
            setLoading(false);
        }
    };

    const handleSearchChange = (e) => {
        setSearchValue(e.target.value);
    };

    useEffect(() => {
        setFilteredStocks(
            stocks.filter(stock => stock.name &&
                stock.name.toLowerCase().includes(searchValue.toLowerCase())
            )
        );
    }, [searchValue, stocks]);

    const handleAddStockOpen = () => setOpenAddStock(true);
    const handleAddStockClose = () => {
        setOpenAddStock(false);
        setNewStock({
            stockName: '',
            stockBarcode: '',
            stockCode: '',
            stockDescription: '',
            stockAmount: '',
            stockPrice: '',
        });
    };

    const handleEditStockOpen = (stockId) => {
        const stockToEdit = stocks.find((stock) => stock.id === stockId);
        setEditStock(stockToEdit);
        setOpenEditStock(true);
    };

    const handleEditStockClose = () => {
        setEditStock(null);
        setOpenEditStock(false);
    };

    const handleEditStockChange = (e) => {
        const { name, value } = e.target;
        setEditStock((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };


    const handleEditStockSubmit = async () => {
        const stockToUpdate = {
            id: editStock.id, // Backend'in zorunlu ID alanı
            stockName: editStock.name, // Güncellenen isim
            stockBarcode: editStock.barcode,
            stockCode: editStock.code,
            stockDescription: editStock.description,
            stockAmount: parseInt(editStock.amount, 10), // Sayıya dönüştürme
            stockPrice: parseInt(editStock.salePrices), // Sayıya dönüştürme
            createdTime: editStock.createdTime || new Date().toISOString(), // Eksikse mevcut zaman
        };

        try {
            console.log("Gönderilen güncelleme isteği:", stockToUpdate); // DEBUG

            const response = await StockService.updateStock(stockToUpdate.id, stockToUpdate);

            console.log("Backend'den dönen yanıt:", response); // DEBUG

            if (response.isSuccess) {
                // Eğer backend yanıtı başarılıysa, state'i güncelle
                setStocks((prevStocks) =>
                    prevStocks.map((stock) =>
                        stock.id === stockToUpdate.id
                            ? { ...stock, ...stockToUpdate } // Güncellenen ürünü ekle
                            : stock // Diğerlerini koru
                    )
                );

                toast.success('Stok başarıyla güncellendi!');
                handleEditStockClose();
            } else {
                toast.error('Güncelleme başarısız: ' + (response.message || 'Hata mesajı yok.'));
            }
        } catch (error) {
            console.error('Stok güncellenirken hata oluştu:', error.response?.data || error.message);
            toast.error('Stok güncellenirken bir hata oluştu.');
        }
    };



    const handleAddStockChange = (e) => {
        const { name, value } = e.target;
        setNewStock({ ...newStock, [name]: value });
    };

    const handleAddStockSubmit = async () => {
        // Backend'in beklediği veri formatına uygun bir nesne oluşturuyoruz
        const stockToAdd = {
            stockName: newStock.stockName,
            stockBarcode: newStock.stockBarcode,
            stockCode: newStock.stockCode,
            stockDescription: newStock.stockDescription,
            stockAmount: parseInt(newStock.stockAmount, 10), // String'den sayıya çeviriyoruz
            stockPrice: parseFloat(newStock.stockPrice), // String'den ondalıklı sayıya çeviriyoruz
        };

        try {
            console.log('Gönderilen yeni stok:', stockToAdd); // DEBUG: Gönderilen veri

            // Backend API'ye yeni stok ekleme isteği gönderiliyor
            const response = await StockService.addNewStock(stockToAdd);

            console.log('Backend yanıtı:', response); // DEBUG: Backend'den dönen yanıtı logluyoruz

            // Eğer backend başarılı bir yanıt döndüyse
            if (response.isSuccess) {
                toast.success('Yeni stok başarıyla eklendi!');

                // Yeni verileri backend'den tekrar çekiyoruz
                await fetchStocks();

                // Formu kapatıyoruz ve sıfırlıyoruz
                handleAddStockClose();
            } else {
                // Backend'den gelen hata mesajını ekrana yazdırıyoruz
                toast.error('Stok ekleme başarısız: ' + (response.message || 'Hata mesajı yok.'));
            }
        } catch (error) {
            // İstek sırasında oluşabilecek tüm hataları burada yakalıyoruz
            console.error('Yeni stok eklenirken hata oluştu:', error.response?.data || error.message);
            toast.error('Yeni stok eklenirken bir hata oluştu.');
        }
    };


    const hadleDeleteStock = async (stockId) => {
        if (!window.confirm('Ürünü silmek istediğinize emin misiniz?')) {
            return;
        }

        try {
            const response = await StockService.deleteStock(stockId);

            if (response.isSuccess) {
                setStocks((prevStocks) =>
                    prevStocks.filter((stock) => stock.id !== stockId)
                );
                toast.success("Ürün başarıyla silindi");
            } else {
                const errorDescription = response.description || "Hata açıklaması mevcut değil.";
                toast.error(`Silme işlemi başarısız: ${errorDescription}`);
            }
        } catch (err) {
            console.error('Stok silinirken hata oluştu:', err);
            toast.error('Silme işlemi sırasında bir hata oluştu.');
        }
    };

    const handleSellStockOpen = (stockId) => {
        setSellStock({ stock_id: stockId, amount: 0 });
        setOpenSellStock(true);
    };

    const handleSellStockClose = () => {
        setOpenSellStock(false);
        setSellStock({ stock_id: '', amount: 0 });
    };

    const handleSellStockSubmit = async () => {
        const stockToUpdate = stocks.find(stock => stock.id === sellStock.stock_id);

        if (!stockToUpdate) {
            alert('Stok bulunamadı!');
            return;
        }

        if (stockToUpdate.amount < sellStock.amount) {
            alert('Yeterli stok bulunmuyor!');
            return;
        }

        const newAmount = stockToUpdate.amount - sellStock.amount;
        const newAveragePrice = Number((
            (stockToUpdate.avaragePrices * stockToUpdate.amount -
                sellStock.amount * stockToUpdate.salePrices) /
            newAmount
        ).toFixed(2));

        const updatedStock = {
            ...stockToUpdate,
            amount: newAmount,
            avaragePrices: newAmount > 0 ? newAveragePrice : 0,
        };

        try {
            await StockService.updateStock(sellStock.stock_id, updatedStock);
            setStocks((prevStocks) =>
                prevStocks.map((stock) =>
                    stock.id === stockToUpdate.id ? { ...stock, ...stockToUpdate } : stock
                )
            );

            alert('Stok başarıyla güncellendi.');
            handleSellStockClose();
        } catch (error) {
            console.error('Stok güncellenirken hata oluştu:', error);
        }
    };

    const columns = [
        { field: 'barcode', headerName: 'Barcode', width: 150 },
        { field: 'code', headerName: 'Code', width: 150 },
        { field: 'name', headerName: 'Name', width: 200 },
        { field: 'description', headerName: 'Description', width: 250 },
        { field: 'amount', headerName: 'Amount', width: 100 },
        { field: 'salePrices', headerName: 'Sale Price', width: 150 },
        { field: 'avaragePrices', headerName: 'Average Price', width: 150 },
        {
            field: 'actions',
            headerName: 'Actions',
            width: 300,
            renderCell: (params) => (
                <div style={{ display: 'flex', gap: '10px' }}>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={() => handleSellStockOpen(params.row.id)}
                    >
                        Satış Yap
                    </Button>
                    <Button
                        variant="contained"
                        color="error"
                        onClick={() => hadleDeleteStock(params.row.id)}
                    >
                        Sil
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={() => handleEditStockOpen(params.row.id)}
                    >
                        Düzenle
                    </Button>
                </div>
            ),
        },
    ];

    return (
        <div style={{ width: '100%' }}>
            <Box display="flex" alignItems="center" justifyContent="space-between" marginBottom={2}>
                <TextField
                    label="Ürün ismine göre ara"
                    variant="outlined"
                    value={searchValue}
                    onChange={handleSearchChange}
                    placeholder="Ürün adı girin"
                    fullWidth
                />
                <Button variant="contained" color="primary" onClick={handleAddStockOpen}>
                    Yeni Stok Ekle
                </Button>
            </Box>

            <div style={{ height: 400 }}>
                {loading ? (
                    <LoadingSpinner size={60} message="Loading Stocks" />
                ) : (
                    <DataGrid
                        rows={filteredStocks}
                        columns={columns}
                        pageSize={5}
                        rowsPerPageOptions={[5, 10, 20]}
                        getRowId={(row) => row.id}
                    />
                )}
            </div>

            <Dialog open={openAddStock} onClose={handleAddStockClose}>
                <DialogTitle>Yeni Stok Ekle</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Name"
                        name="stockName"
                        fullWidth
                        value={newStock.stockName}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Barcode"
                        name="stockBarcode"
                        fullWidth
                        value={newStock.stockBarcode}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Code"
                        name="stockCode"
                        fullWidth
                        value={newStock.stockCode}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Description"
                        name="stockDescription"
                        fullWidth
                        value={newStock.stockDescription}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Amount"
                        name="stockAmount"
                        type="number"
                        fullWidth
                        value={newStock.stockAmount}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Sale Price"
                        name="stockPrice"
                        type="number"
                        fullWidth
                        value={newStock.stockPrice}
                        onChange={handleAddStockChange}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleAddStockClose} color="secondary">
                        İptal
                    </Button>
                    <Button onClick={handleAddStockSubmit} color="primary">
                        Ekle
                    </Button>
                </DialogActions>
            </Dialog>

            <Dialog open={openSellStock} onClose={handleSellStockClose}>
                <DialogTitle>Stoktan Satış Yap</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Satış Miktarı"
                        type="number"
                        value={sellStock.amount}
                        onChange={(e) =>
                            setSellStock({ ...sellStock, amount: Number(e.target.value) })
                        }
                        fullWidth
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleSellStockClose} color="secondary">
                        İptal
                    </Button>
                    <Button onClick={handleSellStockSubmit} color="primary">
                        Sat
                    </Button>
                </DialogActions>
            </Dialog>

            <Dialog open={openEditStock} onClose={handleEditStockClose}>
                <DialogTitle>Stok Düzenle</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Name"
                        name="name"
                        fullWidth
                        value={editStock?.name || ''}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Barcode"
                        name="barcode"
                        fullWidth
                        value={editStock?.barcode || ''}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Code"
                        name="code"
                        fullWidth
                        value={editStock?.code || ''}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Description"
                        name="description"
                        fullWidth
                        value={editStock?.description || ''}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Amount"
                        name="amount"
                        type="number"
                        fullWidth
                        value={editStock?.amount || ''}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Sale Price"
                        name="salePrices"
                        type="number"
                        fullWidth
                        value={editStock?.salePrices || ''}
                        onChange={handleEditStockChange}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleEditStockClose} color="secondary">
                        İptal
                    </Button>
                    <Button onClick={handleEditStockSubmit} color="primary">
                        Güncelle
                    </Button>
                </DialogActions>
            </Dialog>

            <ToastContainer />
        </div>
    );
};

export default StockPage;

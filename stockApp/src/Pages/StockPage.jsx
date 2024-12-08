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


const StockPage = () => {
    const [stocks, setStocks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [searchValue, setSearchValue] = useState('');
    const [filteredStocks, setFilteredStocks] = useState([]);
    const [openAddStock, setOpenAddStock] = useState(false);
    const [openEditStock, setOpenEditStock] = useState(false);
    const [openSellStock, setOpenSellStock] = useState(false);

    const [newStock, setNewStock] = useState({
        Name: '',
        Barcode: '',
        Code: '',
        Description: '',
        Amount: '',
        SalePrices: '',
    });

    const [editStock, setEditStock] = useState({
        id: '',
        Name: '',
        Barcode: '',
        Code: '',
        Description: '',
        Amount: '',
        SalePrices: '',
    });

    const [sellStock, setSellStock] = useState({
        stockId: '',
        amountToSell: 0,
    });

    useEffect(() => {
        fetchStocks();
    }, []);

    const fetchStocks = async () => {
        setLoading(true);
        try {
            const response = await StockService.getAllStocks();
            setStocks(response);
            setFilteredStocks(response);
        } catch (error) {
            toast.error('Data dönerken hata oluştu', error.message);
        } finally {
            setLoading(false);
        }
    };

    const handleSearchChange = (e) => {
        setSearchValue(e.target.value);
    };

    useEffect(() => {
        setFilteredStocks(
            stocks.filter(stock =>
                stock.Name.toLowerCase().includes(searchValue.toLowerCase())
            )
        );
    }, [searchValue, stocks]);

    const handleAddStockOpen = () => setOpenAddStock(true);
    const handleAddStockClose = () => setOpenAddStock(false);

    const handleEditStockOpen = (stock) => {
        setEditStock(stock);
        setOpenEditStock(true);
    };

    const handleEditStockClose = () => setOpenEditStock(false);

    const handleSellStockOpen = (stockId) => {
        setSellStock({ stockId, amountToSell: 0 });
        setOpenSellStock(true);
    };

    const handleSellStockClose = () => setOpenSellStock(false);

    const handleAddStockChange = (e) => {
        const { name, value } = e.target;
        setNewStock({ ...newStock, [name]: value });
    };

    const handleEditStockChange = (e) => {
        const { name, value } = e.target;
        setEditStock({ ...editStock, [name]: value });
    };

    const handleSellStockChange = (e) => {
        setSellStock({ ...sellStock, amountToSell: parseInt(e.target.value, 10) || 0 });
    };

    const handleAddStockSubmit = async () => {
        const stockToAdd = {
            ...newStock,
            Amount: parseInt(newStock.Amount, 10) || 0,
            SalePrices: parseFloat(newStock.SalePrices).toFixed(2),
            avaragePrices: parseFloat(newStock.SalePrices).toFixed(2),
        };

        try {
            await StockService.addNewStock(stockToAdd);
            fetchStocks();
            handleAddStockClose();
            toast.success('Yeni stok başarıyla eklendi')
        } catch (error) {
            toast.error('Yeni stok eklenirken hata oluştu:', error);
        }
    };

    const handleEditStockSubmit = async () => {
        const stockToUpdate = {
            ...editStock,
            Amount: parseInt(editStock.Amount, 10) || 0,
            SalePrices: parseFloat(editStock.SalePrices).toFixed(2),
        };

        try {
            await StockService.updateStock(editStock.id, stockToUpdate);
            fetchStocks();
            handleEditStockClose();
            toast.success('Stok başarıyla güncellendi!');
        } catch (error) {
            toast.error('Stok güncellenirken hata oluştu:', error);
        }
    };

    const handleSellStockSubmit = async () => {
        const stockToSell = stocks.find(stock => stock.id === sellStock.stockId);

        if (!stockToSell || stockToSell.Amount < sellStock.amountToSell) {
            toast.error('Yeterli stok bulunmuyor!');
            return;
        }

        const updatedStock = {
            ...stockToSell,
            Amount: stockToSell.Amount - sellStock.amountToSell,
        };

        try {
            await StockService.updateStock(sellStock.stockId, updatedStock);
            fetchStocks();
            handleSellStockClose();
            toast.success('Stok satıldı!');
        } catch (error) {
            toast.error('Satış sırasında hata oluştu:', error);
        }
    };

    const handleDeleteStock = async (stockId) => {
        if (!window.confirm('Bu stoğu silmek istediğinizden emin misiniz?')) return;

        try {
            await StockService.deleteStock(stockId);
            fetchStocks();
            toast.success('Stok başarıyla silindi!');
        } catch (error) {
            toast.error('Stok silinirken hata oluştu:', error);
        }
    };

    const columns = [
        { field: 'Barcode', headerName: 'Barcode', width: 150 },
        { field: 'Code', headerName: 'Code', width: 150 },
        { field: 'Name', headerName: 'Name', width: 200 },
        { field: 'Description', headerName: 'Description', width: 250 },
        { field: 'Amount', headerName: 'Amount', width: 100 },
        { field: 'SalePrices', headerName: 'Sale Price', width: 150 },
        {
            field: 'actions',
            headerName: 'Actions',
            width: 300,
            renderCell: (params) => (
                <div style={{ display: 'flex', gap: '10px' }}>
                    <Button
                        variant="contained"
                        color="success"
                        onClick={() => handleEditStockOpen(params.row)}
                    >
                        Düzenle
                    </Button>
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
                        onClick={() => handleDeleteStock(params.row.id)}
                    >
                        Sil
                    </Button>
                </div>
            ),
        },
    ];

    return (
        <div>
            <Box display="flex" justifyContent="space-between" mb={2}>
                <TextField
                    label="Ürün Ara"
                    value={searchValue}
                    onChange={handleSearchChange}
                    fullWidth
                />
                <Button variant="contained" color="primary" onClick={handleAddStockOpen}>
                    Yeni Stok Ekle
                </Button>
            </Box>
            <div style={{ height: 400 }}>
                {loading ? (
                    <div>Loading...</div>
                ) : (
                    <DataGrid
                        rows={filteredStocks}
                        columns={columns}
                        pageSize={5}
                        getRowId={(row) => row.id}
                    />
                )}
            </div>

            {/* Dialoglar */}
            <Dialog open={openAddStock} onClose={handleAddStockClose}>
                <DialogTitle>Yeni Stok Ekle</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Name"
                        name="Name"
                        fullWidth
                        value={newStock.Name}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Barcode"
                        name="Barcode"
                        fullWidth
                        value={newStock.Barcode}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Code"
                        name="Code"
                        fullWidth
                        value={newStock.Code}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Description"
                        name="Description"
                        fullWidth
                        value={newStock.Description}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Amount"
                        name="Amount"
                        type="number"
                        fullWidth
                        value={newStock.Amount}
                        onChange={handleAddStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Sale Price"
                        name="SalePrices"
                        type="number"
                        fullWidth
                        value={newStock.SalePrices}
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

            <Dialog open={openEditStock} onClose={handleEditStockClose}>
                <DialogTitle>Stok Güncelle</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Name"
                        name="Name"
                        fullWidth
                        value={editStock.Name}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Barcode"
                        name="Barcode"
                        fullWidth
                        value={editStock.Barcode}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Code"
                        name="Code"
                        fullWidth
                        value={editStock.Code}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Description"
                        name="Description"
                        fullWidth
                        value={editStock.Description}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Amount"
                        name="Amount"
                        type="number"
                        fullWidth
                        value={editStock.Amount}
                        onChange={handleEditStockChange}
                    />
                    <TextField
                        margin="dense"
                        label="Sale Price"
                        name="SalePrices"
                        type="number"
                        fullWidth
                        value={editStock.SalePrices}
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

            <Dialog open={openSellStock} onClose={handleSellStockClose}>
                <DialogTitle>Satış Yap</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Satış Miktarı"
                        type="number"
                        fullWidth
                        value={sellStock.amountToSell}
                        onChange={handleSellStockChange}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleSellStockClose} color="secondary">
                        İptal
                    </Button>
                    <Button onClick={handleSellStockSubmit} color="primary">
                        Satış Yap
                    </Button>
                </DialogActions>
            </Dialog>
            <ToastContainer />
        </div>
    );
};

export default StockPage;

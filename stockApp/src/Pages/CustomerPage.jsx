import React, { useState } from 'react'
import Box from '@mui/material/Box';
import { DataGrid } from '@mui/x-data-grid';
import Button from '@mui/material/Button';



const columns = [
    { field: 'Customer_id', headerName: 'Müşteri ID', width: 150 },
    { field: 'customer_name', headerName: 'Müşteri Ünvanı', width: 250 },
    { field: 'customer_tckn', headerName: 'Müşteri Tckn', width: 250 },
    { field: 'customer_adress', headerName: 'Müşteri Adress', width: 200 },
    {
        field: 'action', headerName: 'Action', width: 200,
        renderCell: (params) => (
            <div style={{ display: 'flex', gap: '15px' }}>
                <Button
                    variant="contained"
                    color="primary"
                    onClick={() => handleEditCustomer(params.row)}
                >
                    Düzenle
                </Button>
                <Button
                    variant="contained"
                    color="error"
                    onClick={() => handleDeleteCustomer(params.row.id)}
                >
                    Sil
                </Button>
            </div>
        )
    }
];

// Örnek bir rows dizisi ekleyelim
const rows = [
    { id: 1, Customer_id: 'C001', customer_name: 'Ali Veli', customer_tckn: '12345678901', customer_adress: 'İstanbul' },
    { id: 2, Customer_id: 'C002', customer_name: 'Ahmet Mehmet', customer_tckn: '98765432109', customer_adress: 'Ankara' },
    { id: 3, Customer_id: 'C003', customer_name: 'Zeynep Yılmaz', customer_tckn: '45612378945', customer_adress: 'İzmir' }
];

function CustomerPage() {
    const [addNewCostumer, setAddNewCostumer] = useState(false)
    const handleaddNewCostumer = () => setAddNewCostumer(true);
    const handleAddNewCostumerClose = () => {
        setAddNewCostumer(false);
        setAddNewCostumer({
            Customer_id: '',
            customer_name: '',
            customer_tckn: '',
            customer_adress: ''
        })
    }
    return (
        <>
            <div >
                <Button sx={{
                    marginTop: "5",
                    marginBottom: "20px",
                    marginLeft: '10px',
                    display: "block", // Row'da doğru hizalama için
                }} variant='contained' onClick={addNewCostumer}>
                    Yeni Müşteri ekle
                </Button>
            </div>
            <div>
                <Box sx={{ height: 400, width: '100%' }}>
                    <DataGrid
                        columns={columns}
                        rows={rows}
                        pageSize={5}
                        getRowId={(row) => row.id}
                    />
                </Box>
            </div>
        </>
    );
}

export default CustomerPage;

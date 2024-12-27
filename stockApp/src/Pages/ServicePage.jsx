import React from 'react'
import Box from '@mui/material/Box';
import { DataGrid } from '@mui/x-data-grid';
import Button from '@mui/material/Button';
import NewService from '../components/newService';


const columns = [
    { field: 'Customer_id', headerName: 'Müşteri ID', width: 150 },
    { field: 'customer_phone', headerName: 'İletişim No', width: 150 },
    { field: 'customer_adress', headerName: 'İş Adress', width: 150 },
    { field: 'amount', headerName: 'Tutar', width: 75 },
    { field: 'Status', headerName: 'Hesap Durumu', width: 150 },
    {
        field: 'action', headerName: 'Action', width: 400,
        renderCell: (params) => (
            <div style={{ display: 'flex', gap: '5px' }}>
                <Button variant="contained" color="primary" onClick={() => alert('Hesap Güncelleme')}>
                    Güncelle
                </Button>
                <Button variant="contained" color="secondary" onClick={() => alert('Hesap Silme')}>
                    Sil
                </Button>
                <Button variant="contained" color="info" onClick={() => alert('Hesap Ödemesi')}>
                    Ödeme
                </Button>
                <Button variant="contained" color="success" onClick={() => alert('Hesap Kapama')}>
                    Kapama
                </Button>

            </div>
        )
    }
]

const rows = [
    { Customer_id: '1', customer_phone: '05351234567', customer_adress: 'Adres1', amount: 100, Status: 'Açık' },
    { Customer_id: '2', customer_phone: '05352345678', customer_adress: 'Adres2', amount: 200, Status: 'Kapalı' },
    { Customer_id: '3', customer_phone: '05353456789', customer_adress: 'Adres3', amount: 300, Status: 'Açık' },
    //... more data
]

function ServicePage() {
    return (
        <>
            <div style={{ gap: '20px' }}>
                <NewService />
            </div>
            <div style={{ marginTop: '20px' }}>
                <Box sx={{ height: 500, width: '100%' }}>
                    <DataGrid
                        rows={rows}
                        columns={columns}
                        pageSize={5}
                        rowsPerPageOptions={[5, 10, 20]}
                        getRowId={(row) => row.Customer_id}
                    />
                </Box>
            </div>
        </>
    )
}

export default ServicePage

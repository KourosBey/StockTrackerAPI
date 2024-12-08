// src/Config/routerConfig.jsx
import StockPage from '../pages/StockPage';
import CustomerPage from '../pages/CustomerPage';
import OfferPage from '../pages/OfferPage';
import ServicePage from '../pages/ServicePage';
import CariPage from '../pages/CariPage';

const routes = [
    { path: '/', element: <StockPage />, label: 'Stok' },
    { path: '/customers', element: <CustomerPage />, label: 'Müşteriler' },
    { path: '/offers', element: <OfferPage />, label: 'Teklifler' },
    { path: '/services', element: <ServicePage />, label: 'Servisler' },
    { path: '/cari', element: <CariPage />, label: 'Cari' },
];

export default routes;

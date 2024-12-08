import React from 'react';
import { CircularProgress, Box } from '@mui/material';

const LoadingSpinner = ({ size = 40, message = '' }) => {
    return (
        <Box
            display="flex"
            justifyContent="center"
            alignItems="center"
            height="100%"
            flexDirection="column"
        >
            <CircularProgress size={size} />
            {message && <p style={{ marginTop: '10px' }}>{message}</p>} {/* Opsiyonel mesaj */}
        </Box>
    );
};

export default LoadingSpinner;

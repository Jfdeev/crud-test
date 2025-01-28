
import React, { useEffect, useState } from 'react';
import { Typography } from '@mui/material';
import axios from 'axios';

const Dashboard = () => {
    const [quantidadeProdutos, setQuantidadeProdutos] = useState(0);

    useEffect(() => {
        const fetchQuantidade = async () => {
            const response = await axios.get('/api/produto');
            setQuantidadeProdutos(response.data.length);
        };
        fetchQuantidade();
    }, []);

    return (
        <div>
            <Typography variant="h4">Dashboard</Typography>
            <Typography>Quantidade de Produtos: {quantidadeProdutos}</Typography>
        </div>
    );
};

export default Dashboard;

import React, { useState } from 'react';
import { TextField, Button } from '@mui/material';
import axios from 'axios';

const ProdutoForm = () => {
    const [nome, setNome] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        await axios.post('/api/produto', { nome });
        setNome('');
    };

    return (
        <form onSubmit={handleSubmit}>
            <TextField
                label="Nome do Produto"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
            />
            <Button type="submit">Cadastrar</Button>
        </form>
    );
};

export default ProdutoForm;
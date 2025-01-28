
import React, { useEffect, useState } from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Button } from '@mui/material';
import axios from 'axios';

const ProdutoList = () => {
    const [produtos, setProdutos] = useState([]);

    useEffect(() => {
        const fetchProdutos = async () => {
            const response = await axios.get('/api/produto');
            setProdutos(response.data);
        };
        fetchProdutos();
    }, []);

    const handleDelete = async (id) => {
        await axios.delete(`/api/produto/${id}`);
        setProdutos(produtos.filter(produto => produto.id !== id));
    };

    return (
        <TableContainer>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Nome</TableCell>
                        <TableCell>Ações</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {produtos.map((produto) => (
                        <TableRow key={produto.id}>
                            <TableCell>{produto.nome}</TableCell>
                            <TableCell>
                                <Button onClick={() => handleDelete(produto.id)}>Deletar</Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
};

export default ProdutoList;
import React from 'react';
import './App.css';

import { Home } from './components/Home'
import { Book } from './components/Book'
import { Category } from './components/Category'


import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

function App() {
    return (
        <BrowserRouter>
            <div className="container">

                <h2 className="m-3 d-flex justify-content-center">
                    Reading List
                </h2>

                <Navbar bg="primary" variant="light">
                    <Container>
                        <Navbar.Brand href="/Home">ReadingList</Navbar.Brand>
                        <Nav className="justify-content-end flex-grow-1 pe-3">
                            <Nav.Link href="/Home">Home</Nav.Link>
                            <Nav.Link href="/Book">Book</Nav.Link>
                            <Nav.Link href="/Category">Category</Nav.Link>
                        </Nav>
                    </Container>
                </Navbar>

                <Routes>
                    <Route path='/Home' element={<Home/>} />
                    <Route path='/Book' element={<Book/>} />
                    <Route path='/Category' element={<Category/>} />
                </Routes>

            </div>
        </BrowserRouter>
    );
}

export default App;
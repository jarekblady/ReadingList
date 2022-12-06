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


                <Navbar bg="primary" variant="dark">
                    <Container>
                        <Navbar.Brand href="/">ReadingList</Navbar.Brand>
                        <Nav className="me-auto">
                            <Nav.Link href="/">Home</Nav.Link>
                            <Nav.Link href="/book">Book</Nav.Link>
                            <Nav.Link href="/category">Category</Nav.Link>
                        </Nav>
                    </Container>
                </Navbar>

                <h2 className="m-3 d-flex justify-content-center">
                    Reading List
                </h2>

                <Routes>
                    <Route path='/' element={<Home/>} exact />
                    <Route path='/book' element={<Book/>} />
                    <Route path='/category' element={<Category/>} />
                </Routes>

            </div>
        </BrowserRouter>
    );
}

export default App;
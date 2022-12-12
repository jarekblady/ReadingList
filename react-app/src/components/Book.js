import React, { Component } from 'react';
import { Table } from 'react-bootstrap';

import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddBookModal } from './AddBookModal';
import { EditBookModal } from './EditBookModal';

export class Book extends Component {

    constructor(props) {
        super(props);
        this.state = { books: [], addModalShow: false, editModalShow: false }
    }

    componentDidMount() {
        this.refreshList();
    }

    refreshList() {
        fetch('https://localhost:7187/api/book')
            .then(response => response.json())
            .then(data => {
                this.setState({ books: data });
            }
            );
    }
    componentDidUpdate() {
        this.refreshList();
    }


    deleteBook(id) {
        if (window.confirm('Are you sure?')) {
            fetch('https://localhost:7187/api/book/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }
    changeIsRead(id) {
        if (window.confirm('Are you sure?')) {
            fetch('https://localhost:7187/api/book/IsRead/' + id, {
                method: 'PUT',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }



    render() {

        const { books, id, order, title, author, categoryid, isread } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });


        return (
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Order</th>
                            <th>Title</th>
                            <th>Author</th>
                            <th>Category</th>
                            <th>IsRead</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {books.map(book =>
                            <tr key={book.id}>
                                <td>{book.order}</td>
                                <td>{book.title}</td>
                                <td>{book.author}</td>
                                <td>{book.categoryName}</td>
                                <td>                                   
                                        <input class="form-check-input" type="checkbox" checked={book.isRead} disabled />   
                                </td>
                                <td>
                                    <ButtonToolbar>
                                        <Button
                                            className="mr-2" variant="info"
                                            onClick={() => this.setState({ editModalShow: true, id: book.id, order: book.order, isread: book.isRead, title: book.title, author: book.author, categoryid: book.categoryId })}
                                        >Edit</Button>

                                        <Button className="mr-2"
                                            onClick={() => this.deleteBook(book.id)}
                                            variant="danger"
                                        >Delete</Button>

                                        <Button className="mr-2"
                                            onClick={() => this.changeIsRead(book.id)}
                                            variant="success"
                                        >IsRead</Button>

                                        <EditBookModal
                                            show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            id={id}
                                            order={order}
                                            title={title}
                                            author={author}
                                            isread={isread}
                                            categoryid={categoryid}

                                        />

                                    </ButtonToolbar>

                                </td>
                            </tr>
                        )}
                    </tbody>
                </Table>



                <ButtonToolbar>
                    <Button
                        variant='primary'
                        onClick={() => this.setState({ addModalShow: true})}
                    >Add Book</Button>

                    <AddBookModal
                        show={this.state.addModalShow}
                        onHide={addModalClose}
                    />

                </ButtonToolbar>
            </div>
        )
    }

}
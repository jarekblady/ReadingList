import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class AddBookModal extends Component {
    constructor(props) {
        super(props);
        this.state = { categories: []};

    }

    componentDidMount() {
        fetch('https://localhost:7187/api/category')
            .then(response => response.json())
            .then(data => {
                this.setState({ categories: data });
            });
    }


    handleSubmit(event) {
        event.preventDefault();
        fetch('https://localhost:7187/api/book', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                order: event.target.order.value,
                title: event.target.title.value,
                author: event.target.author.value,
                categoryId: event.target.categoryId.value,
                isRead: event.target.isRead.checked,
                categoryName: "",
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
            },
                (error) => {
                    alert('Failed')
                }
            )
    }



    render() {
        return (
            <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Add New Book
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <div className="container">
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>

                                    <Form.Group controlId="order">
                                        <Form.Label>order</Form.Label>
                                        <Form.Control
                                            type="number"
                                            required
                                        />
                                    </Form.Group>

                                    <Form.Group controlId="title">
                                        <Form.Label>title</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="title"
                                            required
                                            placeholder="title"
                                        />
                                    </Form.Group>

                                    <Form.Group controlId="author">
                                        <Form.Label>author</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="author"
                                            required
                                            placeholder="author"
                                        />
                                    </Form.Group>

                                    <Form.Group controlId="isRead">
                                        <Form.Check
                                            type="checkbox"
                                            label="isRead"
                                        />
                                    </Form.Group>


                                    <Form.Group controlId="categoryId">
                                        <Form.Label>categoryId</Form.Label>

                                        <Form.Control as="select" required>
                                            <option value="" hidden>Select Category </option>
                                            {this.state.categories.map(category =>
                                                <option key={category.id} value={category.id}>{category.name}</option>
                                            )}
                                        </Form.Control>

                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Add Book
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </div>


                </Modal.Body>
                <Modal.Footer>
                    <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                </Modal.Footer>
            </Modal>
        );
    }
}
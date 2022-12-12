import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class EditBookModal extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: [],
            validationTitle: "",
            validationOrderList: "",
            validationAuthor: "",
        };
        this.handleSubmit = this.handleSubmit.bind(this);

    }


    componentDidMount() {
        fetch('https://localhost:7187/api/category/')
            .then(response => response.json())
            .then(data => {
                this.setState({ categories: data });
            });
    }


    handleSubmit(event) {
        event.preventDefault();
        fetch('https://localhost:7187/api/book/' + event.target.id.value, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: event.target.id.value,
                orderList: event.target.orderList.value,
                title: event.target.title.value,
                author: event.target.author.value,
                categoryId: event.target.categoryId.value,
                isRead: event.target.isRead.checked,
                categoryName: "",


            })
        })
            .then(res => res.json())
            .then((result) => {
                this.validation(result.errors)
            },
                (error) => {
                    alert('Failed')
                }
            )
    }

    validation = (e) => {
        this.setState({
            validationTitle: e.Title !== undefined ? e.Title[0] : "",
            validationOrderList: e.OrderList !== undefined ? e.OrderList[0] : "",
            validationAuthor: e.Author !== undefined ? e.Author[0] : "",

        })

    }



    render() {
        const { validationTitle, validationAuthor, validationOrderList } = this.state;
        return (
            <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Edit Book
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <div className="container">
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>

                                    <Form.Group controlId="id">
                                        <Form.Label>id</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="id"
                                            disabled
                                            defaultValue={this.props.id}
                                            placeholder="id"
                                        />
                                    </Form.Group>

                                    <Form.Group controlId="orderList">
                                        <Form.Label>orderList</Form.Label>
                                        <Form.Control
                                            type="number"
                                            defaultValue={this.props.orderlist}
                                        />
                                        <p class="text-danger">{validationOrderList}</p>
                                    </Form.Group>

                                    <Form.Group controlId="title">
                                        <Form.Label>title</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="title"
                                            defaultValue={this.props.title}
                                            placeholder="title"
                                        />
                                        <p class="text-danger">{validationTitle}</p>
                                    </Form.Group>

                                    <Form.Group controlId="author">
                                        <Form.Label>author</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="author"
                                            defaultValue={this.props.author}
                                            placeholder="author"
                                        />
                                        <p class="text-danger">{validationAuthor}</p>
                                    </Form.Group>

                                    <Form.Group controlId="isRead">
                                        <Form.Check
                                            type="checkbox"
                                            label="isRead"
                                            defaultChecked={this.props.isread}

                                        />
                                    </Form.Group>


                                    <Form.Group controlId="categoryId">
                                        <Form.Label>categoryId</Form.Label>

                                        <Form.Control as="select" defaultValue={this.props.categoryid}>
                                            {this.state.categories.map(category =>
                                                <option key={category.id} value={category.id}>{category.name}</option>
                                            )}
                                        </Form.Control>
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Update Book
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
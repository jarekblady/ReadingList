import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class EditCategoryModal extends Component {
    constructor(props) {
        super(props);

    }


    handleSubmit(event) {
        event.preventDefault();
        fetch('https://localhost:7187/api/category/' + event.target.id.value, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: event.target.id.value,
                name: event.target.name.value
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
                        Edit Category
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
                                            required
                                            disabled
                                            defaultValue={this.props.id}
                                            placeholder="id"
                                        />
                                    </Form.Group>

                                    <Form.Group controlId="name">
                                        <Form.Label>name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="name"
                                            required
                                            defaultValue={this.props.name}
                                            placeholder="name"
                                        />
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Update Category
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
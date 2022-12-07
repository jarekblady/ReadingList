import React, { Component } from 'react';
import { Table } from 'react-bootstrap';

import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddCategoryModal } from './AddCategoryModal';
import { EditCategoryModal } from './EditCategoryModal';

export class Category extends Component {

    constructor(props) {
        super(props);
        this.state = { categories: [], addModalShow: false, editModalShow: false}
    }

    componentDidMount() {
        this.refreshList();
    }
    
    refreshList() {
        fetch('https://localhost:7187/api/category')
            .then(response => response.json())
            .then(data => {
                this.setState({ categories : data });
            }
            );
    }
    componentDidUpdate() {
        this.refreshList();
    }

    /*
    refreshList() {
        this.setState({
            categories: [{ "Id": 1, "Name": "Horror" },
                { "Id": 2, "Name": "Science-fiction" }
            ]
        })
    }
    */

    deleteCategory(id) {
        if (window.confirm('Are you sure?')) {
            fetch('https://localhost:7187/api/category/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }



    render() {

        const { categories, id, name } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });

        
        return (
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories.map(category =>
                            <tr key={category.id}>
                                <td>{category.id}</td>
                                <td>{category.name}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button
                                            className="mr-2" variant="info"
                                            onClick={() => this.setState({ editModalShow: true, id: category.id, name: category.name })}
                                        >Edit</Button>

                                        <Button className="mr-2"
                                            onClick={() => this.deleteCategory(category.id)}
                                            variant="danger"
                                        >Delete</Button>
    
                                        <EditCategoryModal
                                            show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            id={id}
                                            name={name}
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
                        onClick={() => this.setState({ addModalShow: true })}
                    >Add Category</Button>

                    <AddCategoryModal
                        show={this.state.addModalShow}
                        onHide={addModalClose}
                    />

                </ButtonToolbar>
            </div>
        )
    }

}
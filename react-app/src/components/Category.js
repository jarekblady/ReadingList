import React, { Component } from 'react';
import { Table } from 'react-bootstrap';

import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddCategoryModal } from './AddCategoryModal';

export class Category extends Component {

    constructor(props) {
        super(props);
        this.state = { categories: [], addModalShow: false}
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


    render() {

        const { categories } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        
        return (
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories.map(category =>
                            <tr key={category.id}>
                                <td>{category.id}</td>
                                <td>{category.name}</td>
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
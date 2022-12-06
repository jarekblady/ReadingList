import React, { Component } from 'react';
import { Table } from 'react-bootstrap';

//import { Button, ButtonToolbar } from 'react-bootstrap';

export class Category extends Component {

    constructor(props) {
        super(props);
        this.state = { categories: []}
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
        const { categories} = this.state
        
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
            </div>
        )
    }

}
import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';

export class ContentDashboard extends React.Component<{ Show: boolean }, {}> {
    constructor(props) {
        super(props);
    }

    render() {
        if (!this.props.Show)
            return null;
        else {
            return (
                <div>
                    <h1>Dashboard Cutie Shop</h1>
                    <div>
                        <div>

                        </div>
                        <div>
                        </div>
                    </div>
                </div>
            );
        }
    }
}
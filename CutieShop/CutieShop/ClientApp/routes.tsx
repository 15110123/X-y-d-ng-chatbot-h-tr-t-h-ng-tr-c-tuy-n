import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Search } from "./components/Search/Search"
import { Dashboard } from './components/Dashboard_nv/Dashboard';

var isEmployee: boolean = true;

export const routes = <Layout>
    <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/search" component={Search} />
        <Route path="/dashboardnv">
            <Dashboard IsAllowAccess={isEmployee} />
            </Route>
    </Switch>
</Layout>;

import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Search } from "./components/Search/Search"
import { Dashboard } from './components/Dashboard_nv/Dashboard';
import { DashboardLayout } from "./components/DashboardLayout"

var isEmployee: boolean = true;

export const routes = <Layout>
    <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/search" component={Search} />
        {/*N?u path l� "/dashboardnv..." th� v�o Route n�y*/}
        <Route path="/dashboardnv">
            <Dashboard IsAllowAccess={isEmployee} />
        </Route>
    </Switch>
</Layout>;

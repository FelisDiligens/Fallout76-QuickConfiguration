import React from "react";
import {
    Button,
    Container,
    Row,
    Col,
    Stack,
    Tabs,
    Tab,
    ProgressBar,
    FormCheck,
    Form,
    Alert,
} from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
    faPuzzlePiece,
    faBox,
    faGear,
    faCircleInfo,
} from "@fortawesome/free-solid-svg-icons";
import "./TabContent.css";
import {getData} from "../messages.js";

/*registerMessageHandler((msg, data) => {
    alert(msg + "\n" + JSON.stringify(data, null, 4));
});*/

var data = {
    modCount: 0,
    modsEnabled: 0,
    progressPercent: 50
}

getData((recvData) => {
    data = {...data, ...recvData};
});

export default class App extends React.Component {
    render() {
        return (
            <Container fluid>
                <Row>
                    <Tabs defaultActiveKey="modorder" className="mb-3">
                        <Tab
                            eventKey="modorder"
                            title={
                                <span>
                                    <FontAwesomeIcon icon={faPuzzlePiece} /> Mod
                                    order
                                </span>
                            }
                        >
                            <Row>
                                <Col md="auto">Tools</Col>
                                <Col>Mod list</Col>
                                <Col md="auto">Mod details</Col>
                            </Row>
                        </Tab>
                        <Tab
                            eventKey="resources"
                            title={
                                <span>
                                    <FontAwesomeIcon icon={faBox} /> Resource
                                    list
                                </span>
                            }
                        >
                            <p className="fs-3">Resource list</p>
                            <p>TODO: Put the resource list here...</p>
                            <Stack direction="horizontal" gap={3}>
                                <Button variant="outline-primary">
                                    Clean list
                                </Button>
                                <Button variant="outline-primary">Reset</Button>
                                <Button variant="outline-primary">
                                    Apply changes
                                </Button>
                            </Stack>
                        </Tab>
                        <Tab
                            eventKey="settings"
                            title={
                                <span>
                                    <FontAwesomeIcon icon={faGear} /> Settings
                                </span>
                            }
                        >
                            <p className="fs-3">Settings</p>
                            <p className="fs-4">Behavior</p>
                            <Alert variant="info">
                                <FontAwesomeIcon icon={faCircleInfo} />
                                &nbsp; These settings only take effect after
                                deployment.
                            </Alert>
                            <p className="fs-5">How to copy files?</p>
                            <Form>
                                <Form.Check
                                    label="Make hard links (recommended)"
                                    name="group-copy-files"
                                    type="radio"
                                    id="hardLinks"
                                    defaultChecked
                                />
                                <Form.Check
                                    label="Make symbolic links (experimental, needs admin rights)"
                                    name="group-copy-files"
                                    type="radio"
                                    id="symLinks"
                                />
                                <Form.Check
                                    label="Copy files (most stable)"
                                    name="group-copy-files"
                                    type="radio"
                                    id="copyFiles"
                                />
                            </Form>
                            <br />
                            <p className="fs-5">Where to put bundled archives in the load order?</p>
                            <Form>
                                <Form.Check
                                    label="Put bundled archives first (default)"
                                    name="group-bundled-load-order"
                                    type="radio"
                                    id="bundledFirst"
                                    defaultChecked
                                />
                                <Form.Check
                                    label="Put bundled archives last"
                                    name="group-bundled-load-order"
                                    type="radio"
                                    id="bundledLast"
                                />
                            </Form>
                            <br />
                            <Form>
                                <Form.Check
                                    label="Unfreeze *.ba2 files by default"
                                    type="checkbox"
                                    id="unfreezeBA2"
                                />
                                <Form.Check
                                    label="Freeze bundled archives (experimental)"
                                    type="checkbox"
                                    id="freezeBundledArchives"
                                />
                            </Form>
                            <br />
                            <p className="fs-4">Interface</p>
                            <Form>
                                <Form.Check
                                    label="Show the mod title from the NexusMods page if available."
                                    type="checkbox"
                                    id="showRemoteModTitle"
                                />
                            </Form>
                        </Tab>
                    </Tabs>
                </Row>
                <Row>
                    <Col>
                        <span style={{ color: "green" }}>Ready...</span>
                        <ProgressBar now={data.progressPercent} />
                    </Col>
                    <Col md="auto">
                        <FormCheck
                            type="switch"
                            label="Enable mods"
                            defaultChecked
                        />
                        <Button style={{ width: "200px" }}>Deploy</Button>
                    </Col>
                </Row>
                <Row>
                    <Col md="auto">
                        <span className="fw-bold">Mod count:</span>&nbsp;
                        <span>{data.modCount}</span>
                    </Col>
                    <Col md="auto">
                        <span className="fw-bold">Enabled:</span>&nbsp;
                        <span>{data.modsEnabled}</span>
                    </Col>
                    <Col>
                        <p className="text-end fw-bold">Deployment necessary</p>
                    </Col>
                </Row>
            </Container>
        );
    }
}

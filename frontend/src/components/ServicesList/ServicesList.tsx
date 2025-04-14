import {useGetApiServiceQuery} from "../../features/api/api.gen.ts";

const ServicesList = () => {
    const {data: services = []} = useGetApiServiceQuery({});

    return (
        <div>
            {services.map((service: any) => (
                <div key={service.id}>{service.name}</div>
            ))}
        </div>
    );
};

export default ServicesList;
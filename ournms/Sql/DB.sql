-- Equipment Table
CREATE TABLE public.equipment (
      id bigserial NOT NULL,
      ip varchar NOT NULL,
      "name" varchar NOT NULL,
      CONSTRAINT equipment_pk PRIMARY KEY (id),
      CONSTRAINT ip_unique UNIQUE (ip)
);
CREATE INDEX equipment_id_idx ON public.equipment (id);
CREATE INDEX equipment_ip_idx ON public.equipment (ip);
CREATE INDEX equipment_name_idx ON public.equipment ("name");

--------------------------------------------------------------------------------